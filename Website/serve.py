import http.server
import socketserver

PORT = 8000                     # ← change this easily if needed

Handler = http.server.SimpleHTTPRequestHandler

# Fix MIME types so .js, .css etc. work properly
Handler.extensions_map.update({
    '.js': 'application/javascript',
    '.css': 'text/css',
    '.json': 'application/json',
    '.svg': 'image/svg+xml',
    '.avif': 'image/avif',
    '.webp': 'image/webp'
})

with socketserver.TCPServer(("127.0.0.1", PORT), Handler) as httpd:
    print(f"✅ Serving on http://127.0.0.1:{PORT}")
    print("   (Press Ctrl+C to stop)")
    httpd.serve_forever()